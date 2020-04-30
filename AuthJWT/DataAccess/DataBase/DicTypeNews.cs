using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class DicTypeNews
    {
        public DicTypeNews()
        {
            TraNews = new HashSet<TraNews>();
        }

        public int TynIdTypePk { get; set; }
        public string TynName { get; set; }
        public string TynDescription { get; set; }
        public bool TynState { get; set; }

        public virtual ICollection<TraNews> TraNews { get; set; }
    }
}
