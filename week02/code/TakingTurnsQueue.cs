using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public int Turns { get; }

}

public class TakingTurnsQueue
{
    private class PersonState
    {
        public string Name { get; set; }
        public int TurnsRemaining { get; set; }

        public PersonState(string name, int turns)
        {
            Name = name;
            TurnsRemaining = turns;
        }

        public bool HasInfiniteTurns => TurnsRemaining <= 0;
    }

    private Queue<PersonState> _queue = new Queue<PersonState>();

    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new PersonState(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _queue.Dequeue();

        // Return a snapshot of the person's data before any mutation
        var returnPerson = new Person(person.Name, person.TurnsRemaining);

        if (person.HasInfiniteTurns)
        {
            // Infinite turns: re-add without decrementing
            _queue.Enqueue(person);
        }
        else if (person.TurnsRemaining > 1)
        {
            // Decrement and re-add if they have remaining turns
            person.TurnsRemaining--;
            _queue.Enqueue(person);
        }

        return returnPerson;
    }
}
