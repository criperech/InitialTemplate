using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class TraNews
    {
        public string NewIdNewPk { get; set; }
        public int? NewIdUserCreatorFk { get; set; }
        public int NewIdImageFk { get; set; }
        public int NewIdTypeFk { get; set; }
        public string NewTitle { get; set; }
        public string NewShortDescription { get; set; }
        public string NewLongDescription { get; set; }
        public string NewSecondTitle { get; set; }
        public DateTime NewInitialValidDate { get; set; }
        public DateTime NewEndValidDate { get; set; }
        public DateTime NewStartDate { get; set; }
        public DateTime NewLastUpdate { get; set; }
        public bool? NewMore { get; set; }
        public bool NewState { get; set; }

        public virtual DicTypeNews NewIdTypeFkNavigation { get; set; }
    }
}
