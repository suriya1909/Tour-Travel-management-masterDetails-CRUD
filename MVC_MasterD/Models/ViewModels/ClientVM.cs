using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MasterD.Models.ViewModels
{
    public class ClientVM
    {
        public int ClientId { get; set; }
        [Required, Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required, Display(Name = "Birth Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase PictureFile { get; set; }
        public bool MaritalStatus { get; set; }

        public List<int> SpotList { get; set; } = new List<int>();
    }
}