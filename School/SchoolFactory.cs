namespace WrestlerApp.School;

/// <summary>
/// Generates a list Of 8 Schools.
/// </summary>
public static class SchoolFactory
{
    /// <summary>
    /// Generates the School List.
    /// </summary>
    /// <returns>A List of 8 Schools.</returns>
    public static List<School> GenerateSchoolList()
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        List<School> schoolList = new List<School>();
        for (int i = 1; i <= 8; i++)
        {
            schoolList.Add(new School(i * 100, rand));
        }
        return schoolList;
    }
}