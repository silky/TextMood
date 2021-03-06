using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

using TextMood.Backend.Common;

namespace TextMood.Functions
{
	[StorageAccount(QueueNameConstants.AzureWebJobsStorage)]
	public static class SaveTextModelToDatabase
	{
		[FunctionName(nameof(SaveTextModelToDatabase))]
		public static void Run(
			[QueueTrigger(QueueNameConstants.TextModelForDatabase)]TextMoodModel textModel,
			[Queue(QueueNameConstants.SendUpdate)] out TextMoodModel textModelOutput,
			TraceWriter log)
		{
			log.Info("Saving TextModel to Database");

			if (textModel.Text.Length > 128)
				textModel.Text = textModel.Text.Substring(0, 128);

			TextMoodDatabase.InsertTextModel(textModel).GetAwaiter().GetResult();

			textModelOutput = textModel;
		}
	}
}
