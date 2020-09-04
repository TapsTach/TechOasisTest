using System;
using System.Collections.Generic;
using System.Text;

namespace TechOasisTest.Shared.DTO
{
    public class SearchModel<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}
