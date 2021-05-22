using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.ErrorService.Models
{
    public class ErrorModel
    {
        public int Status { get; set; }
        public ErrorText Errors { get; set; }
    }

    public class ErrorText 
    {
        public List<string> Mark { get; set; }
        public List<string> Model { get; set; }
        public List<string> Year { get; set; }
        public List<string> Capacity { get; set; }
        public List<string> Image { get; set; }

        public List<string> GetAll() 
        {
            List<string> result = new List<string>();
            if(Mark != null)
                result.AddRange(Mark);
            if (Model != null)
                result.AddRange(Model);
            if (Year != null)
                result.AddRange(Year);
            if (Capacity != null)
                result.AddRange(Capacity);
            if (Image != null)
                result.AddRange(Image);

            return result;
        }
    }
}
