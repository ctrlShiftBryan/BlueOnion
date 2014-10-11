using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModel
{
    public class KOMapping
    {

        public KOMapping()
        {
            ignore = new List<string>();
            ignorePostBack = new List<string>();
            copy = new List<string>() { "KOMapping.copy" };
        }
        public List<String> ignore { get; set; }
        public List<String> copy { get; set; }
        public List<String> ignorePostBack { get; set; }
        public List<String> allNonPostBack {
            get { return copy.Union(ignorePostBack).ToList(); }
        } 
    }
}
