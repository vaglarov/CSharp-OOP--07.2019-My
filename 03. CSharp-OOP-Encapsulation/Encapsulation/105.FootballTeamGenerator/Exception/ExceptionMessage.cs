namespace FootballTeamGenerator.Exception
{
    public static class ExceptionMessega
    {
        public static string InvalidName = "A name should not be empty.";
        public static string InvalidStats = "{0} should be between {1} and {2}.";
        public static string PlayerExistInThisTeam = "{0} still play in {1}";
        public static string PlayeDoNotExistInTeam = "Player {0} is not in {1} team.";
        public static string TeamDoNotExist = "Team {0} does not exist.";

    }
}
