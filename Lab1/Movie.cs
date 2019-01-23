using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public enum MovieRating
    {
        Unknown,
        G,
        PG,
        PG13,
        R,
        NC17
    }
    class Movie : IMedia
    {
        private int _ID = 0;
        private string _Title = string.Empty;
        private string _Publisher = string.Empty;
        private string _Creator = string.Empty;
        private DateTime _PublishDate = DateTime.MinValue;
        private int _RunLength = 0;

        public MovieRating Rating { get; set; } = MovieRating.Unknown;
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value > 0)
                {
                    _ID = value;
                }
                else
                {
                    throw new ArgumentException("ID must be a positive value!", "ID");
                }
            }
        }


        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _Title = value;
                }
                else
                {
                    throw new ArgumentException("Title cannot be blank!", "Title");
                }
            }
        }
        public string Publisher
        {
            get
            {
                return _Publisher;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Publisher = value;
                }
                else
                {
                    throw new ArgumentException("Publisher cannot be blank!", "Publisher");
                }
            }
        }

        public string Creator
        {
            get
            {
                return _Creator;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _Creator = value;
                }
                else
                {
                    throw new ArgumentException("Creator cannot be blank", "Creator");
                }
            }
        }

        public DateTime PublishDate
        {
            get
            {
                return _PublishDate;
            }
            set
            {               
                DateTime.TryParse("1/1/1878", out DateTime earliestKnownMovie); 

                if(DateTime.Compare(value, earliestKnownMovie) > 0) // Movie publish data is later than earliest known movie
                {
                    _PublishDate = value;
                }
                else
                {
                    throw new ArgumentException("Publish data cannot be earlier than Jan 1, 1878", "PublishDate");
                }

            }
        }

        public int RunLength
        {
            get
            {
                return _RunLength;
            }
            set
            {
                if(value > 0)
                {
                    _RunLength = value;
                }
                else
                {
                    throw new ArgumentException("Run Length cannot be a negative number!", "RunLength");
                }
            }
        }

        public Movie() { }

        public Movie (int ID, string title, string publisher, string creator, DateTime publishDate, int runLenth, MovieRating rating)
        {
            this.ID = ID;
            Title = title;
            Publisher = publisher;
            Creator = creator;
            PublishDate = publishDate;
            RunLength = runLenth;
            Rating = rating;
        }

        public int GetAge()
        {
            DateTime currentTime = DateTime.Now;
            int ageInYear = currentTime.Year - PublishDate.Year;

            //if the month/day of publish date is greater than current month/date, then minus 1 year 
            if (PublishDate.Month > currentTime.Month || PublishDate.Month == currentTime.Month && PublishDate.Day > currentTime.Day)
            {
                --ageInYear;
            }

            return ageInYear;
        }

        public void Print()
        {
            Console.Write($"Movie:{ID,9}  {Title,-25}  {Publisher,-20}{Creator,-20}{PublishDate:yyyy-MM-dd} (Age: {GetAge()}) {RunLength,4}  {Rating}");
        }
    }
}
