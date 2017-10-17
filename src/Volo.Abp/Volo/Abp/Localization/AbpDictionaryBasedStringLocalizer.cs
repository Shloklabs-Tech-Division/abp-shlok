﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace Volo.Abp.Localization
{
    public class AbpDictionaryBasedStringLocalizer : IStringLocalizer
    {
        public LocalizationResource Resource { get; }

        public AbpDictionaryBasedStringLocalizer(LocalizationResource resource)
        {
            Resource = resource;
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return GetAllStrings(CultureInfo.CurrentUICulture.Name, includeParentCultures);
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public LocalizedString this[string name] => GetLocalizedString(name, CultureInfo.CurrentUICulture.Name);

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var localizedString = this[name];
                return new LocalizedString(name, string.Format(localizedString.Value, arguments, localizedString.ResourceNotFound, localizedString.SearchedLocation));
            }
        }

        protected virtual LocalizedString GetLocalizedString(string name, string cultureName)
        {
            var value = GetLocalizedStringOrNull(name, cultureName);

            if (value == null)
            {
                return new LocalizedString(name, name, true);
            }

            return value;
        }

        protected virtual LocalizedString GetLocalizedStringOrNull(string name, string cultureName, bool tryDefaults = true)
        {
            var dictionaries = Resource.DictionaryProvider.Dictionaries;

            //Try to get from original dictionary (with country code)
            ILocalizationDictionary originalDictionary;
            if (dictionaries.TryGetValue(cultureName, out originalDictionary))
            {
                var strOriginal = originalDictionary.GetOrNull(name);
                if (strOriginal != null)
                {
                    return new LocalizedString(name, strOriginal.Value);
                }
            }

            if (!tryDefaults)
            {
                return null;
            }

            //Try to get from same language dictionary (without country code)
            if (cultureName.Contains("-")) //Example: "tr-TR" (length=5)
            {
                ILocalizationDictionary langDictionary;
                if (dictionaries.TryGetValue(GetBaseCultureName(cultureName), out langDictionary))
                {
                    var strLang = langDictionary.GetOrNull(name);
                    if (strLang != null)
                    {
                        return new LocalizedString(name, strLang.Value);
                    }
                }
            }

            //Try to get from default language
            var defaultDictionary = Resource.DictionaryProvider.Dictionaries[Resource.DefaultCultureName]; //TODO: What if not contains a default dictionary?
            if (defaultDictionary == null)
            {
                return null;
            }

            var strDefault = defaultDictionary.GetOrNull(name);
            if (strDefault == null)
            {
                return null;
            }

            return new LocalizedString(name, strDefault.Value);
        }

        protected virtual IReadOnlyList<LocalizedString> GetAllStrings(string cultureName, bool includeDefaults = true)
        {
            //TODO: Can be optimized (example: if it's already default dictionary, skip overriding)

            var dictionaries = Resource.DictionaryProvider.Dictionaries;

            //Create a temp dictionary to build
            var allStrings = new Dictionary<string, LocalizedString>();

            if (includeDefaults)
            {
                //Fill all strings from default dictionary
                var defaultDictionary = Resource.DictionaryProvider.Dictionaries[Resource.DefaultCultureName]; //TODO: What if not contains a default dictionary?
                if (defaultDictionary != null)
                {
                    foreach (var defaultDictString in defaultDictionary.GetAllStrings())
                    {
                        allStrings[defaultDictString.Name] = new LocalizedString(defaultDictString.Name, defaultDictString.Value);
                    }
                }

                //Overwrite all strings from the language based on country culture
                if (cultureName.Contains("-"))
                {
                    ILocalizationDictionary langDictionary;
                    if (dictionaries.TryGetValue(GetBaseCultureName(cultureName), out langDictionary))
                    {
                        foreach (var langString in langDictionary.GetAllStrings())
                        {
                            allStrings[langString.Name] = new LocalizedString(langString.Name, langString.Value);
                        }
                    }
                }
            }

            //Overwrite all strings from the original dictionary
            ILocalizationDictionary originalDictionary;
            if (dictionaries.TryGetValue(cultureName, out originalDictionary))
            {
                foreach (var originalLangString in originalDictionary.GetAllStrings())
                {
                    allStrings[originalLangString.Name] = new LocalizedString(originalLangString.Name, originalLangString.Value);
                }
            }

            return allStrings.Values.ToImmutableList();
        }

        protected virtual string GetBaseCultureName(string cultureName)
        {
            return cultureName.Contains("-")
                ? cultureName.Left(cultureName.IndexOf("-", StringComparison.Ordinal))
                : cultureName;
        }
    }
}