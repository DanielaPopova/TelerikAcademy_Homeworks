namespace Events
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    public class EventOperator
    {
        private static StringBuilder output = new StringBuilder();

        private static EventHolder events = new EventHolder();

        public static void Main(string[] args)
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(output);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            if (command[0] == 'A')
            {
                AddEvent(command);
                return true;
            }

            if (command[0] == 'D')
            {
                DeleteEvents(command);
                return true;
            }

            if (command[0] == 'L')
            {
                ListEvents(command);
                return true;
            }

            if (command[0] == 'E')
            {
                return false;
            }

            return false;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            string commandType = "ListEvents";
            DateTime date = GetDate(command, commandType);
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string deleteEventCommand = "DeleteEvents";
            string title = command.Substring(deleteEventCommand.Length + 1);

            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            string commandType = "AddEvent";

            GetParameters(command, commandType, out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            string dateFormat = command.Substring(commandType.Length + 1, 20);
            DateTime date = DateTime.Parse(dateFormat);

            return date;
        }

        public static class Messages
        {
            public static void EventAdded()
            {
                output.Append("Event added\n");
            }

            public static void EventDeleted(int count)
            {
                if (count == 0)
                {
                    NoEventsFound();
                }
                else
                {
                    output.AppendFormat("{0} events deleted\n", count);
                }
            }

            public static void NoEventsFound()
            {
                output.Append("No events found\n");
            }

            public static void PrintEvent(Event eventToPrint)
            {
                if (eventToPrint != null)
                {
                    output.Append(eventToPrint + "\n");
                }
            }
        }

        public class EventHolder
        {
            private MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);
            private OrderedBag<Event> eventsByDate = new OrderedBag<Event>();

            public void AddEvent(DateTime date, string title, string location)
            {
                Event newEvent = new Event(date, title, location);
                this.eventsByTitle.Add(title.ToLower(), newEvent);
                this.eventsByDate.Add(newEvent);

                Messages.EventAdded();
            }

            public void DeleteEvents(string titleToDelete)
            {
                string title = titleToDelete.ToLower();
                int removed = 0;

                foreach (var eventToRemove in this.eventsByTitle[title])
                {
                    removed++;
                    this.eventsByDate.Remove(eventToRemove);
                }

                this.eventsByTitle.Remove(title);
                Messages.EventDeleted(removed);
            }

            public void ListEvents(DateTime date, int count)
            {
                OrderedBag<Event>.View eventsToShow = this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
                int showed = 0;

                foreach (var eventToShow in eventsToShow)
                {
                    if (showed == count)
                    {
                        break;
                    }

                    Messages.PrintEvent(eventToShow);

                    showed++;
                }

                if (showed == 0)
                {
                    Messages.NoEventsFound();
                }                
            }
        }       
    }
}
