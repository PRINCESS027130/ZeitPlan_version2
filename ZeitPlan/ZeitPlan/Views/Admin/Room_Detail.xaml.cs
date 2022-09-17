using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeitPlan.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Room_Detail : ContentPage
    {
        public Room_Detail(TBL_ROOM r)
        {
            InitializeComponent();
            LoadData(r);
           
        }
        async void LoadData(TBL_ROOM r)
        {
            try
            {
                var Department = (await App.firebaseDatabase.Child("TBL_DEPARTMENT").OnceAsync<TBL_DEPARTMENT>()).FirstOrDefault(x => x.Object.DEPARTMENT_ID == r.DEPARTMENT_FID);
                RoomNumber.Text = r.ROOM_NO;
                DepartmentFID.Text = r.DEPARTMENT_FID.ToString();
            }
            catch (Exception ex)
            {
                //LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong Please try again later.\nError:" + ex.Message, "ok");
                return;

            }
        }
    }
}