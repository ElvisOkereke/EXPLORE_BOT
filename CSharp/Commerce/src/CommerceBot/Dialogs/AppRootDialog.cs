using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CommerceBot.Dialogs
{
    // Model Id == App Id that you'll find in LUIS Portal
    // Find at: https://www.luis.ai/home/keys 
    // Subscription Key is one of the two keys from your Cognitive Services App.
    // Find at: https://portal.azure.com in the Resource Group where you've created
    // your Cognitive Services resource on the Keys blade.
    [LuisModel("3463b76d-f327-4ca9-86a0-18cdcf9c24b0", "db2fd8cac9b5406088e22c7e7a088fc6")]
    [Serializable]
    public class AppRootDialog : LuisDialog<object>
    {
        private const string EntityBike = "Bike";
        private const string EntityBikeChain = "Chain";
        private const string EntityBikeFrame = "Frame";
        private const string EntityBikeCrankset = "Crankset";
        private const string EntityBikeWheels = "Wheels";
        private const string EntityBikeTires = "Tires";

        [LuisIntent("BikeParts.Frames")] //incomplete
        public async Task BikeFrames(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::BikeFrames");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityBikeFrame, out EntityRecommendation bikeFrameRec) || bikeFrameRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in BikeFrames.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("I see you want to buy a bike frame.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }

        [LuisIntent("BikeParts.Crankset")] //incomplete
        public async Task BikeCrankset(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::BikeCrank");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityBikeCrankset, out EntityRecommendation bikeCrankRec) || bikeCrankRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in BikeCrank.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("I see you want to buy a bike crankset.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }

        [LuisIntent("BikeParts.Wheels")] //incomplete
        public async Task BikeWheels(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::BikeWheels");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityBikeWheels, out EntityRecommendation bikeWheelRec) || bikeWheelRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in BikeWheels.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("I see you want to buy bike wheels.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }     

        [LuisIntent("BikeParts.Chains")] //incomplete
        public async Task BikeChains(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::BikeChains");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityBikeChain, out EntityRecommendation bikeChainRec) || bikeChainRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in BikeChains.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("I see you want to buy a bike chain.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }


        [LuisIntent("BikeParts.Tires")] //incomplete
        public async Task BikeTires(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::BikeTires");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityBikeTires, out EntityRecommendation bikeTireRec) || bikeTireRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in BikeTires.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("I see you want to buy bike tires.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }

        [LuisIntent("Bike.Menu")]
        public async Task BikeMenu(IDialogContext context,
                                 IAwaitable<IMessageActivity> activity,
                                 LuisResult result)
        {
            Trace.TraceInformation("AppRootDialog::BikeMenu");

            var message = await activity;
            IAwaitable<object> awaitableMessage = await activity as IAwaitable<object>;

            if (!result.TryFindEntity(EntityBike, out EntityRecommendation bikeRec) || bikeRec.Score <= .5)
            {
                Trace.TraceWarning("Low Confidence in BikeMenu.");

                await context.PostAsync($"I'm sorry, I don't understand '{message.Text}'.");
                context.Wait(this.MessageReceived);
                return;
            }

            await context.PostAsync("I see you want to buy a bike.");

            await context.Forward(new AppAuthDialog(),
                this.ResumeAfterHotelServicesDialog, message, CancellationToken.None);
        }

        private async Task ResumeAfterHotelServicesDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Thank you. We're all done. What else can I do for you?");

            context.Done<object>(null);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi! Try asking me 'What bikes do you have?'.");

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
    }
}