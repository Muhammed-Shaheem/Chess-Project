using System.Windows.Media;

namespace Chess.Desktop;

public class PlaySound
{
    private MediaPlayer moveSound = new MediaPlayer();
    private MediaPlayer captureSound = new MediaPlayer();
    private MediaPlayer notificationSound = new MediaPlayer();

    public PlaySound()
    {
        moveSound.Open(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Sounds\\move-self.mp3"));
        captureSound.Open(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Sounds\\capture.mp3"));
        notificationSound.Open(new Uri("C:\\Users\\shahe\\source\\repos\\Chess-Project\\ChessApp\\Chess.Desktop\\Sounds\\notify.mp3"));
    }

    public void PlayMoveSound()
    {
        moveSound.Stop(); // reset if playing already
        moveSound.Play();
    }

    public void PlayCaptureSound()
    {
        captureSound.Stop();
        captureSound.Play();
    }
    public void PlayNotifySound()
    {
        notificationSound.Stop();
        notificationSound.Play();
    }
}
