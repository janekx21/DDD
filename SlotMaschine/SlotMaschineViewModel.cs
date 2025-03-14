using Spectre.Console;

namespace SlotMaschine;

public class SlotMaschineViewModel
{
    public string Message { get; set; } = string.Empty;
    public SlotMaschineViewModel(SlotMaschine slotMaschine)
    {
        SlotMaschine = slotMaschine;
        view = new View();
        insertCent = new Action(() => InsertMoney(Money.Cent));
        pullLever = new Action(() => PullLever());
    }

    public View view { get; set; }

    public Action pullLever { get; set; }

    public Action insertCent { get; set; }

    public SlotMaschine SlotMaschine { get; set; }

    public void InsertMoney(Money coin)
    {
        SlotMaschine.InsertCoin(coin);
        // Notify
        Message =
            $"You have inserted {coin.Amount}€.\nIn maschine {SlotMaschine.MoneyInTransaction.Amount}€";
    }

    public void PullLever()
    {
        SlotMaschine.PullLeaver();
        Message = "You have pulled the lever.";
    }

    public void Start()
    {
        while (true)
        {
            var nextAction = view.Show(Message);
            switch (nextAction)
            {
                case "Add Cent":
                    insertCent();
                    break;
                case "Pull the leaver":
                    pullLever();
                    break;
                case "Exit":
                    return;
                default:
                    throw new Exception("Unimplemented action");
            }
        }
    }
}