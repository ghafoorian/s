#if __IOS__
using Foundation;
#endif
using System;


namespace SharedProject
{
#if __IOS__
    public class Product : NSObject
    {
        public static readonly string JobTypeTitle = "Job type title";

        public string Title { get; private set; }
        public string ListType { get; private set; }

        public Product (string listType, string title)
        {
            ListType = listType;
            Title = title;
        }
    }
#endif
}

