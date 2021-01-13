using ABSA.PhoneBookAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ABSA.PhoneBookAPI.Data
{
    /// <summary>
    ///     Represents the object which will initialize the database when the project is started up.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        ///     Creating and setting up of database and running new migrations.
        /// </summary>
        /// <param name="context">
        ///     A <see cref="PhoneBookContext" /> representing the db context.
        /// </param>
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.Migrate();
        }
    }
}