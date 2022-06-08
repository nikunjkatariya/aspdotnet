using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralDesignPatterns
{
    class JobPost
    {
        public string Title { get; private set; }
        public JobPost(string title)
        {
            Title = title;
        }
    }

    class JobSeeker : IObserver<JobPost>
    {
        public string Name { get; private set; }
        public JobSeeker(string name)
        {
            Name = name;
        }
        //Method is not being called by JobPostings class currently
        public void OnCompleted()
        {
            //No Implementation
            Console.WriteLine("Job Seeker OnCompleted");
        }

        //Method is not being called by JobPostings class currently
        public void OnError(Exception error)
        {
            //No Implementation
            Console.WriteLine("Job Seeker OnError");
        }
        public void OnNext(JobPost value)
        {
            Console.WriteLine($"Hi {Name}! New Job Posted: {value.Title}");
        }
    }

    class JobPostings : IObserver<JobPost>
    {
        private List<IObserver<JobPost>> mObservers;
        private List<JobPost> mJobPostings;

        public JobPostings()
        {
            mObservers = new List<IObserver<JobPost>>();
            mJobPostings=new List<JobPost>();
        }

        public IDisposable Subscribe(IObserver<JobPost> Observer)
        {
            //Check Whether observer is already registered. If not, add it
            if (!mObservers.Contains(Observer))
            {
                mObservers.Add(Observer);
            }
            return new Unsubscriber<JobPost>(mObservers, Observer);
        }

        private void Notify(JobPost jobPost)
        {
            foreach (var observer in mObservers)
            {
                observer.OnNext(jobPost);
            }
        }
        public void AddJob(JobPost jobPost)
        {
            mJobPostings.Add(jobPost);
            Notify(jobPost);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Job Postings OnCompleted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Job Postings OnError");
        }

        public void OnNext(JobPost value)
        {
            Console.WriteLine("Job Postings OnNext");
        }
    }

    internal class Unsubscriber<JobPost> : IDisposable
    {
        private List<IObserver<JobPost>> mObservers;
        private IObserver<JobPost> mObserver;
        internal Unsubscriber(List<IObserver<JobPost>> observers, IObserver<JobPost> observer)
        {
            this.mObservers = observers;
            this.mObserver = observer;
        }
        public void Dispose()
        {
            if(mObservers.Contains(mObserver))
                mObservers.Remove(mObserver);
        }
    }

    internal class ObserverDP
    {
        public void Main()
        {
            //Create Subscribers
            var JohnDoe = new JobSeeker("John Doe");
            var JaneDoe = new JobSeeker("Jane Doe");

            //Create Publisher and attach subscribers
            var jobPostings = new JobPostings();
            jobPostings.Subscribe(JohnDoe);
            jobPostings.Subscribe(JaneDoe);

            //Add new job and see if subscribers get notified
            jobPostings.AddJob(new JobPost("Software Engineer"));

            //Output
            //Hi John Doe! New job Posted: Software Engineer
            Console.ReadLine();
        }
    }
}
