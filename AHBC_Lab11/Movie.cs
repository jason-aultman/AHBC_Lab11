using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_Lab11
{
    class Movie
    {
        private string _title;
        private string _catagory;

        public string Title 
        {
            get
            { 
                return _title;
            }
        }
        public Catagory Catagory
        {
            get
            {
                switch (_catagory)
                {
                    case "animated":
                        return Catagory.animated;
                    case "drama":
                        return Catagory.drama;
                    case "scifi":
                        return Catagory.scifi;
                    case "horror":
                        return Catagory.horror;
                    default:
                        return Catagory;
                        
                }
              
            }
            set
            {
                _catagory=value.ToString();
            }
        }
        public Movie(string title, Catagory catagory)
        {
            _title = title;
            Catagory = catagory;
        }

    }
}
