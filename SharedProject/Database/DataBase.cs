using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;

namespace SharedProject
{
    /// <summary>
    /// A class that contains User table members
    /// </summary>
    [Table("Items")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string UserId { get; set; }
        public string Accesstoken { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string age { get; set; }
        public string Mobile { get; set; }
        public string HandicapFrom { get; set; }
        public string HandicapTo { get; set; }
        public string PostalCode { get; set; }
        public string Biography { get; set; }
        public string Handicap { get; set; }
        public string GolfClubName { get; set; }
        public string GolfClubId { get; set; }
        public byte[] Avatarimg { get; set; }
        public string PreList { get; set; }
        public string MaincourseId { get; set; }
        public string MaincourseName { get; set; }
        public string IsSmoker { get; set; }
        public string MemberTypeId { get; set; }
        public string prefferedSection { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string DefaultServer { get; set; }
        public bool RememberMe { get; set; }
        public string MyMatches { get; set; }
        public string ClubEvents { get; set; }



    }


    static class UserHolder
    {
        #region Flags (Contains some default values)
        public static readonly string DefaultDbName = "membermatch.db3";
        public static readonly string DefaultDbPath =
            Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        #endregion


        #region Class private members 
        private static SQLiteConnection db = null;
        private static User user;

        /// <summary>
        /// Creates the user table.
        /// </summary>
        private static void CreateUserTable()
        {
            try
            {
                db.CreateTable<User>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            user = new User();
            // Initialize table values
            user.UserId = "";
            user.Username = "";
            user.Firstname = "Name";
            user.Lastname = "";
            user.Email = "";
            user.Accesstoken = "";
            user.Mobile = "";
            user.PostalCode = "";
            user.HandicapTo = "";
            user.HandicapFrom = "";
            user.age = "Category";
            user.Biography = "";
            user.Avatarimg = null;
            user.Handicap = "";
            user.GolfClubName = "";
            user.GolfClubId = "";
            user.PreList = "";
            user.MaincourseId = "";
            user.MaincourseName = "";
            user.IsSmoker = "";
            user.MemberTypeId = "";
            user.prefferedSection = "";
            user.Occupation = "";
            user.Gender = "";
            user.DefaultServer = "";
            user.RememberMe = false;
            user.Password = "";
            user.MyMatches = "";
            user.ClubEvents = "";

            var resultTable = db.Table<User>();
            if (!resultTable.Any())
            {
                db.InsertOrReplace(user);
            }
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Creates or opens the user database.
        /// </summary>
        /// <param name="dbPath">Db path.</param>
        /// <param name="dbName">Db name.</param>
        public static void CreateOrOpenDatabase(string dbPath, string dbName)
        {
            // Create new connection
            try
            {
                var dbFullPath = Path.Combine(dbPath, dbName);
                db = new SQLiteConnection(dbFullPath);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Create the user table
            CreateUserTable();
        }



        /// <summary>
        /// Get all user's data.
        /// </summary>
        /// <returns>a row with user data values.</returns>
        public static List<User> GetAllData()
        {
            var resultTable = db.Table<User>();
            return resultTable.ToList();
        }

        /// <summary>
        /// Delete all user's data.
        /// </summary>
        public static void DeleteAllData()
        {
            db.DropTable<User>();
            CreateOrOpenDatabase(DefaultDbPath, DefaultDbName);
        }

        /// <summary>
        /// Closes the database.
        /// </summary>
        public static void CloseDatabase()
        {
            db.Close();
        }
        #endregion

        #region Prperties (For access to any fields of the user table)


        /// <summary>
        /// Gets or sets the user Id.
        /// </summary>
        /// <value>The first name.</value>
        public static string UserId
        {
            get
            {
                return GetAllData()[0].UserId;
            }
            set
            {
                user = GetAllData()[0];
                user.UserId = value;

                db.InsertOrReplace(user);
            }
        }



        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public static string FirstName
        {
            get
            {
                return GetAllData()[0].Firstname;
            }
            set
            {
                user = GetAllData()[0];
                user.Firstname = value;

                db.InsertOrReplace(user);
            }
        }

        /// <summary>
        /// Get or set the last name.
        /// </summary>
        /// <value>The last name.</value>
        public static string LastName
        {
            get { return GetAllData()[0].Lastname; }
            set
            {
                user = GetAllData()[0];
                user.Lastname = value;

                db.InsertOrReplace(user);
            }
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public static string UserName
        {
            get { return GetAllData()[0].Username; }
            set
            {
                user = GetAllData()[0];
                user.Username = value;

                db.InsertOrReplace(user);
            }
        }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        public static string Mobile
        {
            get { return GetAllData()[0].Mobile; }
            set
            {
                user = GetAllData()[0];
                user.Mobile = value;

                db.InsertOrReplace(user);
            }
        }



        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public static string Email
        {
            get { return GetAllData()[0].Email; }
            set
            {
                user = GetAllData()[0];
                user.Email = value;

                db.InsertOrReplace(user);
            }
        }



        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        public static string AccessToken
        {
            get { return GetAllData()[0].Accesstoken; }
            set
            {
                user = GetAllData()[0];
                user.Accesstoken = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        public static string Age
        {
            get { return GetAllData()[0].age; }
            set
            {
                user = GetAllData()[0];
                user.age = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public static string PostalCode
        {
            get { return GetAllData()[0].PostalCode; }
            set
            {
                user = GetAllData()[0];
                user.PostalCode = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the bio graphy.
        /// </summary>
        /// <value>The bio graphy.</value>
        public static string BioGraphy
        {
            get { return GetAllData()[0].Biography; }
            set
            {
                user = GetAllData()[0];
                user.Biography = value;

                db.InsertOrReplace(user);
            }
        }

        /// <summary>
        /// Gets or sets the handicap from.
        /// </summary>
        /// <value>The handicap from.</value>
        public static string HandicapFrom
        {
            get { return GetAllData()[0].HandicapFrom; }
            set
            {
                user = GetAllData()[0];
                user.HandicapFrom = value;


                db.InsertOrReplace(user);
            }
        }



        /// <summary>
        /// Gets or sets the handicap to.
        /// </summary>
        /// <value>The handicap to.</value>
        public static string HandicapTo
        {
            get { return GetAllData()[0].HandicapTo; }
            set
            {
                user = GetAllData()[0];
                user.HandicapTo = value;


                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the handicap.
        /// </summary>
        /// <value>The handicap.</value>
        public static string Handicap
        {
            get { return GetAllData()[0].Handicap; }
            set
            {
                user = GetAllData()[0];
                user.Handicap = value;


                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the name of the golf club.
        /// </summary>
        /// <value>The name of the golf club.</value>
        public static string GolfClubName
        {
            get { return GetAllData()[0].GolfClubName; }
            set
            {
                user = GetAllData()[0];
                user.GolfClubName = value;


                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the golf club identifier.
        /// </summary>
        /// <value>The golf club identifier.</value>
        public static string GolfClubId
        {
            get { return GetAllData()[0].GolfClubId; }
            set
            {
                user = GetAllData()[0];
                user.GolfClubId = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the avatar image.
        /// </summary>
        /// <value>The avatar image.</value>
        public static byte[] AvatarImg
        {
            get { return GetAllData()[0].Avatarimg; }
            set
            {
                user = GetAllData()[0];
                user.Avatarimg = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the pre list.
        /// </summary>
        /// <value>The pre list.</value>
        public static string PreList
        {
            get { return GetAllData()[0].PreList; }
            set
            {
                user = GetAllData()[0];
                user.PreList = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the main course identifier.
        /// </summary>
        /// <value>The main course identifier.</value>
        public static string MainCourseId
        {
            get { return GetAllData()[0].MaincourseId; }
            set
            {
                user = GetAllData()[0];
                user.MaincourseId = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the name of the main course.
        /// </summary>
        /// <value>The name of the main course.</value>
        public static string MainCourseName
        {
            get { return GetAllData()[0].MaincourseName; }
            set
            {
                user = GetAllData()[0];
                user.MaincourseName = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the is smoker.
        /// </summary>
        /// <value>The is smoker.</value>
        public static string IsSmoker
        {
            get { return GetAllData()[0].IsSmoker; }
            set
            {
                user = GetAllData()[0];
                user.IsSmoker = value;

                db.InsertOrReplace(user);
            }
        }



        /// <summary>
        /// Gets or sets the member type identifier.
        /// </summary>
        /// <value>The member type identifier.</value>
        public static string MemberTypeId
        {
            get { return GetAllData()[0].MemberTypeId; }
            set
            {
                user = GetAllData()[0];
                user.MemberTypeId = value;

                db.InsertOrReplace(user);
            }
        }



        /// <summary>
        /// Gets or sets the preffered section.
        /// </summary>
        /// <value>The preffered section.</value>
        public static string prefferedSection
        {
            get { return GetAllData()[0].prefferedSection; }
            set
            {
                user = GetAllData()[0];
                user.prefferedSection = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the occupation.
        /// </summary>
        /// <value>The occupation.</value>
        public static string Occupation
        {
            get { return GetAllData()[0].Occupation; }
            set
            {
                user = GetAllData()[0];
                user.Occupation = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public static string Gender
        {
            get { return GetAllData()[0].Gender; }
            set
            {
                user = GetAllData()[0];
                user.Gender = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the default server.
        /// </summary>
        /// <value>The default server.</value>
        public static string DefaultServer
        {
            get { return GetAllData()[0].DefaultServer; }
            set
            {
                user = GetAllData()[0];
                user.DefaultServer = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the pass word.
        /// </summary>
        /// <value>The pass word.</value>
        public static string PassWord
        {
            get { return GetAllData()[0].Password; }
            set
            {
                user = GetAllData()[0];
                user.Password = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:SharedProject.UserHolder"/> remember me.
        /// </summary>
        /// <value><c>true</c> if remember me; otherwise, <c>false</c>.</value>
        public static bool RememberMe
        {
            get { return GetAllData()[0].RememberMe; }
            set
            {
                user = GetAllData()[0];
                user.RememberMe = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets my matches.
        /// </summary>
        /// <value>My matches.</value>
        public static string MyMatches
        {
            get { return GetAllData()[0].MyMatches; }
            set
            {
                user = GetAllData()[0];
                user.MyMatches = value;

                db.InsertOrReplace(user);
            }
        }


        /// <summary>
        /// Gets or sets the club events.
        /// </summary>
        /// <value>The club events.</value>
        public static string ClubEvents
        {
            get { return GetAllData()[0].ClubEvents; }
            set
            {
                user = GetAllData()[0];
                user.ClubEvents = value;

                db.InsertOrReplace(user);
            }
        }

        #endregion

    }
}