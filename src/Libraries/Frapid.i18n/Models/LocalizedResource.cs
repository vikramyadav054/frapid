﻿namespace Frapid.i18n.Models
{
    public class LocalizedResource
    {
        public long Id { get; set; }
        public string ResourceClass { get; set; }
        public string Key { get; set; }
        public string Original { get; set; }
        public string Translated { get; set; }
    }
}