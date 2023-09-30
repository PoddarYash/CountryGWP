using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace CountryGWP.API.Entities
{
    public class GWPByCountry
    {
        public string Country { get; set; }

        public string VariableId { get; set; }

        public string VariableName { get; set; }

        public string LineOfBusiness { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2000 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2001 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2002 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2003 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2004 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2005 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2006 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2007 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2008 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2009 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2010 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2011 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2012 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2013 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2014 { get; set; }

        [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
        public decimal? Y2015 { get; set; }
    }
}
