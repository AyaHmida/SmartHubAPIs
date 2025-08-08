using SmartHomeHub.API.Helpers.Interfaces;

namespace SmartHomeHub.API.Helpers
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            // Simulation d'envoi d'e-mail (affichage console)
            Console.WriteLine("---------- EMAIL SENDING SIMULATION ----------");
            Console.WriteLine($"TO: {to}");
            Console.WriteLine($"SUBJECT: {subject}");
            Console.WriteLine("BODY:");
            Console.WriteLine(body);
            Console.WriteLine("----------------------------------------------");

            await Task.CompletedTask;
        }
    }
}
