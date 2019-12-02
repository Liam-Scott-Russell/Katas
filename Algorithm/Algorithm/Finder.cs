using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _allPeople;

        public Finder(List<Person> allPeople)
        {
            _allPeople = allPeople;
        }

        public PairOfPeople Find(AgeDifference ageDifference)
        {
            PairOfPeople output = new PairOfPeople();

            if (_allPeople.Count > 1)
            {
                var sortedPeople = SortPeopleByBirthDate();
            
                var possibleOutput = new PairOfPeople[2]
                {
                    GetSmallestAgeDifference(sortedPeople),
                    GetLargestAgeDifference(sortedPeople)
                };

                output =  possibleOutput[(int) ageDifference];
            }

            return output;
        }

        private List<Person> SortPeopleByBirthDate()
        {
            var heap = new Heap(_allPeople.Count);
            foreach (var person in _allPeople)
            {
                heap.Add(person);
            }

            return heap.Sort();
        }

        private PairOfPeople GetLargestAgeDifference(List<Person> sortedPeople)
        {
            var indexOfPastPerson = sortedPeople.Count - 1;
            var oldestPerson = sortedPeople[indexOfPastPerson];
            var youngestPerson = sortedPeople[0];
            var ageGap = oldestPerson.BirthDate - youngestPerson.BirthDate;

            var largestAgeGapPair = new PairOfPeople()
            {
                FirstPerson = youngestPerson,
                SecondPerson = oldestPerson,
                AgeDifference = ageGap
            };

            return largestAgeGapPair;
        }
        
        private PairOfPeople GetSmallestAgeDifference(List<Person> sortedPeople)
        {
            var smallestAgeDifferenceSoFar = new PairOfPeople()
            {
                FirstPerson = sortedPeople[0],
                SecondPerson = sortedPeople[1],
                AgeDifference = sortedPeople[1].BirthDate - sortedPeople[0].BirthDate
            };
            
            for (var i = 0; i < sortedPeople.Count - 1; i++)
            {
                var currentPerson = sortedPeople[i];
                var nextPerson = sortedPeople[i + 1];
                var currentAgeDifference = nextPerson.BirthDate - currentPerson.BirthDate;

                if (currentAgeDifference < smallestAgeDifferenceSoFar.AgeDifference)
                {
                    smallestAgeDifferenceSoFar = new PairOfPeople()
                    {
                        FirstPerson = currentPerson,
                        SecondPerson = nextPerson,
                        AgeDifference = currentAgeDifference
                    };
                }
            }

            return smallestAgeDifferenceSoFar;
        }
    }
}