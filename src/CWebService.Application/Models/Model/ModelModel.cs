using System.Text.Json.Serialization;

namespace CWebService.Application.Models
{
    public class ModelModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public long BrandID { get; set; }
        public string BrandLink { 
            get {
                return "http://localhost:5000/v1/brands/" + BrandID;
            }
         }
    }
}