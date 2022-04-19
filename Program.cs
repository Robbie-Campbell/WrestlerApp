// See https://aka.ms/new-console-template for more information

using WrestlerApp.School;
using WrestlerApp.Tournament;
using WrestlerApp.Match;

var sl = SchoolFactory.GenerateSchoolList();

var tourney = new Tournament(sl);

tourney.CheckTourneyList();

