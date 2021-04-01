using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class WorkPermitTypeViewModel
    {
 

            public int WorkPermitTypeId { get; set; }
            public string Name { get; set; }
            public Nullable<int> CreatedBy { get; set; }
            public Nullable<System.DateTime> CreatedDate { get; set; }
            public Nullable<int> UpdatedBy { get; set; }
            public Nullable<System.DateTime> UdatedDate { get; set; }
            public Nullable<System.DateTime> DeletedDate { get; set; }
            public Nullable<int> DeletedBy { get; set; }
            public List<WorkPermitTypeViewModel>WorkPermitTypeViewModelList{ get; set; }
    }
}