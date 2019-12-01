using System;
using System.Collections.Generic;

namespace Algorithm
{
    public class Heap
    {
        private readonly List<Person> _items;

        public Heap(int heapSize)
        {
            _items = new List<Person>(heapSize + 1);
            _items.Add(null);

        }
        
        public void Add(Person newPerson)
        {
            _items.Add(newPerson);
            PercolateUp(_items.Count - 1);
        }

        private void PercolateUp(int currentIndex)
        {
            while (true)
            {
                var parentIndex = currentIndex / 2;

                // First and only item doesn't need to percolate
                if (currentIndex == 1)
                {
                    break;
                }
                
                if (_items[currentIndex].BirthDate < _items[parentIndex].BirthDate)
                {
                    SwapPeopleByIndex(parentIndex, currentIndex);
                    currentIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void SwapPeopleByIndex(int indexOne, int indexTwo)
        {
            var temp = _items[indexOne];
            _items[indexOne] = _items[indexTwo];
            _items[indexTwo] = temp;
        }

        public Person RemoveMinimum()
        {
            var youngestPerson = _items[1];
            var lastPersonInHeap = _items[_items.Count - 1];
            
            MovePersonToTopOfHeap(lastPersonInHeap);
            
            _items.RemoveAt(_items.Count - 1);

            if (_items.Count > 1)
            {
                PercolateDown(1);
            }
            
            return youngestPerson;
        }

        private void MovePersonToTopOfHeap(Person person)
        {
            if (_items.Count > 1)
            {
                _items[1] = person;
            }
            else
            {
                _items.Add(person);
            }   
        }
        
        private void PercolateDown(int currentIndex)
        {
            while (true)
            {
                if (IsElementInRightPlace(currentIndex))
                {
                    break;
                }

                var indexToSwapWith = GetIndexOfSmallestChild(currentIndex);
                if (indexToSwapWith != -1)
                {
                    SwapPeopleByIndex(currentIndex, indexToSwapWith);
                    currentIndex = indexToSwapWith;
                    continue;
                }

                break;
            }
        }

        private bool IsIndexWithinHeap(int index)
        {
            return index <= _items.Count - 1;
        }

        private int GetIndexOfSmallestChild(int parentIndex)
        {
            var leftChildIndex = 2 * parentIndex;
            var rightChildIndex = 2 * parentIndex + 1;

            if (!IsIndexWithinHeap(rightChildIndex))
            {
                return IsIndexWithinHeap(leftChildIndex) ? leftChildIndex : -1;
            }
            
            var leftChildDate = _items[leftChildIndex].BirthDate;
            var rightChildDate = _items[rightChildIndex].BirthDate;

            return leftChildDate < rightChildDate ? leftChildIndex : rightChildIndex;
        }

        private bool IsElementInRightPlace(int parentIndex)
        {
            var leftChildIndex = 2 * parentIndex;
            var rightChildIndex = 2 * parentIndex + 1;
            
            if (!IsIndexWithinHeap(rightChildIndex))
            {
                if (IsIndexWithinHeap(leftChildIndex))
                {
                    return _items[parentIndex].BirthDate <= _items[leftChildIndex].BirthDate;
                }
                return true;
            }

            var parentDate = _items[parentIndex].BirthDate;
            var leftChildDate = _items[leftChildIndex].BirthDate;
            var rightChildDate = _items[rightChildIndex].BirthDate;

            return parentDate <= leftChildDate && parentDate <= rightChildDate;
        }

        public List<Person> GetSortedElements()
        {
            var sortedPeople = new List<Person>();
            var totalNumberOfPeople = _items.Count - 1;
            
            for (var i = 0; i < totalNumberOfPeople; i++)
            {
                sortedPeople.Add(RemoveMinimum());
            }

            return sortedPeople;
        }
    }
}