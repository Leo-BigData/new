using GalaSoft.MvvmLight;
using MVVMLightWPFSampleApp.Commons;
using MVVMLightWPFSampleApp.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Reactive.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMLightWPFSampleApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly AppContext Model = AppContext.Instance;

        public ReadOnlyReactiveCollection<PersonViewModel> People { get; private set; }

        public ReactiveProperty<PersonViewModel> SelectedPerson { get; private set; }

        public ReactiveCommand LoadCommand { get; private set; }

        public ReactiveCommand DeleteCommand { get; private set; }

        public ReactiveCommand EditCommand { get; private set; }

        public ReactiveCommand AddCommand { get; private set; }

        public ReactiveProperty<PersonViewModel> InputPerson { get; private set; }

        public MainWindowViewModel()
        {
            this.People = this.Model.Master.People
                .ToReadOnlyReactiveCollection(x => new PersonViewModel(x));

            this.SelectedPerson = new ReactiveProperty<PersonViewModel>();

            this.InputPerson = this.Model.Master.ObserveProperty(x => x.InputPerson)
                .Select(x => new PersonViewModel(x))
                .ToReactiveProperty();

            this.AddCommand = this.InputPerson
                .SelectMany(x => x.HasErrors)
                .Select(x => !x)
                .ToReactiveCommand();
            this.AddCommand.Subscribe(_ => this.Model.Master.AddPerson());

            this.LoadCommand = new ReactiveCommand();
            this.LoadCommand.Subscribe(_ => this.Model.Master.Load());

            this.DeleteCommand = this.SelectedPerson
                .Select(x => x != null)
                .ToReactiveCommand();
            this.DeleteCommand
                .SelectMany(_ => DialogService.Default.ShowMessage("削除しますか", "確認", "OK", "Cancel", __ => {}).ToObservable())
                .Where(x => x)
                .Select(_ => this.SelectedPerson.Value.Model.ID)
                .Subscribe(x => this.Model.Master.Delete(x));

            this.EditCommand = this.SelectedPerson
                .Select(x => x != null)
                .ToReactiveCommand();
            this.EditCommand
                .Subscribe(_ =>
                {
                    this.Model.Detail.SetEditTarget(this.SelectedPerson.Value.Model.ID);
                    this.MessengerInstance.Send(new MessageBase(this, "WindowOpen"));
                });
        }
    }
}
