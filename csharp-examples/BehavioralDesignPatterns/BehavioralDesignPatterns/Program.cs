using System;

namespace BehavioralDesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Behavioral Patterns
            //********1.Chain of Responsibility********|HALF DONE
//            new ChainofResponsibility().Main();
            
            //********2.Command********
            //The info. method name and the values for the method parameter.
//            new CommandDP().Main();
            
            //********3.Iterator********
            //It Presents a way to access the elements of an object without exposing the underlyig presentataion.
            //It is a design Pattern in which an iterator is used to traverse a container and access the container's elements.
            //The Iterator pattern decouples algorithms from containers; in some cases, algorithmms are necessarily container-specific and thus cannot be 
//            new IteratorDP().Main();
            //Stack Overflow 

            //********4.Mediator********
            //It adds a third party object called mediator to control the interaction between two objects called colleagues.
            //It helps reduce the coupling between the classes communicating with each other.
            //Because now they don't need to have the knowledge of each other's implementation. 
//            new MediatorDP().Main();
            
            //********5.Memento********
            //It is about Capturing and storing the current state of an object in a menner that it can be restored later on in a smooth manner.
            //It provides the ability to restore an object to its previous state.
//            new Memento().Main();

            //********6.Observer********
            //Defines a dependency between objects so that whenever an object changes it state, all its dependencies are notified.
            //It is a design pattern in which an object called the subject, maintains a list of its dependents called observers and notifies them automatically of any state changes, usually by calling one of their methods.
//            new ObserverDP().Main();

            //********7.Visitor********
            new VisiterDP().Main();

            //********8.Strategy********


            //********9.State********


            //********10.Template Method********
        
        
        }
    }
}
