using Spectre.Console;

namespace SlotMaschine;

public class View
{
    public string Show(string Message)
    {
            AnsiConsole.Write(new Markup("[yellow]SlotMaschine[/]\n"));
            AnsiConsole.Write(new Markup(Message));
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
            var nextAction = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What to do next?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices([
                        "Add Cent",
                        "Pull the leaver",
                        "Exit"
                    ]));

            AnsiConsole.WriteLine();
            return nextAction;

        }
    
}