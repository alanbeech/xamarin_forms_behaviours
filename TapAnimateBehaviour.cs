using Xamarin.Forms;

namespace Idx.MyApp
{
    public class TapAnimateBehaviour : Behavior<View>
    {
        public const double SCALEIN = 0.75;
        public const double SCALEOUT = 1;
        public const int SCALETIME = 60;

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);

            var profileTapRecognizer = new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await bindable.ScaleTo(SCALEIN, SCALETIME, Easing.CubicIn);
                    await bindable.ScaleTo(SCALEOUT, SCALETIME, Easing.CubicOut);
                }),
                NumberOfTapsRequired = 1
            };

            bindable.GestureRecognizers.Add(profileTapRecognizer);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);

            // Perform clean up
            bindable.GestureRecognizers.Clear();
        }
    }
}
