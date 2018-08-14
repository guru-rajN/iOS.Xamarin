using System;
using System.Collections.Generic;

namespace AppraisalApp.Models
{
    public class FactoryOptionsKBB
    {
            public int optionId { get; set; }
            public string isSelected { get; set; }
            public string displayName { get; set; }
            public string categoryName { get; set; }
            public string optionKindId { get; set; }
    }
    public class FactoryOptionsKBBWrapper
    {
        public FactoryOptionsKBBWrapper()
        {
            data = new List<FactoryOptionsKBB>();
        }
        public List<FactoryOptionsKBB> data { get; set; }
    }
}
