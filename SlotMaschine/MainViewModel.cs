namespace SlotMaschine;

public class MainViewModel
{
    public MainViewModel()
    {
        viewModel = new SlotMaschineViewModel(new SlotMaschine());
    }

    public View view { get; set; }

    public SlotMaschineViewModel viewModel { get; set; }

    public void Start()
    {
        viewModel.Start();
    }
}