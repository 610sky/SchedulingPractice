using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.OrTools.Sat;

namespace SchedulingPractice;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var allJobs =
            new[]
            {
                new[]
                    {
                        // job 0
                        new { machine = 0, duration = 3 }, // task 0
                        new { machine = 1, duration = 2 }, // task 1
                        new { machine = 2, duration = 2 }, // task 2
                    }
                    .ToList(),
                new[]
                    {
                        // job 1
                        new { machine = 0, duration = 2 }, // task 0
                        new { machine = 2, duration = 1 }, // task 1
                        new { machine = 1, duration = 4 }, // task 2
                    }
                    .ToList(),
                new[]
                {
                    // job 2
                    new { machine = 1, duration = 4 }, // task 0
                    new { machine = 2, duration = 3 }, // task 1
                }.ToList(),
            }.ToList();

        int numMachines = 0;
        foreach (var job in allJobs)
        {
            foreach (var task in job)
            {
                numMachines = Math.Max(numMachines, 1 + task.machine);
            }
        }

        int[] allMachines = Enumerable.Range(0, numMachines).ToArray();

        int horizon = 0;
        foreach (var job in allJobs)
        {
            foreach (var task in job)
            {
                horizon += task.duration;
            }
        }
        
        // 모델 선언
        CpModel model = new CpModel();
        
        // Dictionary<Tuple<int, int>, Tuple<IntVar,IntVar,IntervalVar>> allTasks=new Dictionary<Tuple
    }
}