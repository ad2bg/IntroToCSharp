using System;
using System.Threading;

namespace IntroToCSharp
{
    class EventsAndDelegates
    {
        // Required steps:  see all required steps in all classes!

        static void Main1()
        {
            var video = new Video { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();     // event publisher
            var mailService = new MailService();       // event subscriber 1
            var messageService = new MessageService(); // event subscriber 2

            // Step 7 - Creating the subscriptions
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            // Calling the method that will raise the event on its completion
            videoEncoder.Encode(video);
        }
    }



    // Simple class
    public class Video
    {
        public string Title { get; set; }
    }



    // Class with an event
    public class VideoEncoder
    {
        public void Encode(Video video)
        {
            // Regular code...
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            Console.WriteLine("Video Encoded.");

            // Step 6 - Calling the method for raising the event!
            OnVideoEncoded(video);
        }

        // Step 1 - Define a delegate
        // (the contract between publisher and subscriber)
        // VideoEventArgs can simply be EventArgs.Empty if we will not be
        // passing anything. Otherwise - we need to define a class - see step 8.
        public delegate void VideoEncodedEventHandler(
            object source, VideoEventArgs e);

        // Step 2 - Define an event based on the delegate
        public event VideoEncodedEventHandler VideoEncoded;

        // Step 3 - Raise the event
        protected virtual void OnVideoEncoded(Video video)
        // must be protected virtual void On+EventName
        {
            // Step 4 - Ensure there's an event & subscribers
            if (VideoEncoded != null)
            {
                // Step 5 - call the event, following the delegate signature
                VideoEncoded(this,     // 'this' is the sending class
                    new VideoEventArgs
                    { Video = video});  //  EventArgs as necessary
            }
        }

        // Step 8 - For sending some EventArgs we need to have a class:
        public class VideoEventArgs : EventArgs
        {
            public Video Video { get; set; }
        }

    }



    // Class which is an event subscriber
    public class MailService
    {
        // Event handler method - must be void and follow the delegate signature
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: Sending an email...");
        }
    }



    // Another class which is an event subscriber
    public class MessageService
    {
        // Event handler method - must be void and follow the delegate signature
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MessageService: Sending a text message...");
        }
    }

}
