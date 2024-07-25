using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace Video_Application.Models
{
    public class Video
    {
        public string FileName { get; set; } 
        public string FilePath { get; set; } 

        public Video(string filename, string filepath)
        {
            FileName = filename;
            FilePath = filepath;    
        }
    }
}
