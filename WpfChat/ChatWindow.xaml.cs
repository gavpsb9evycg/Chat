//#define SERVER
#define CLIENT

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfChat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private readonly ObservableCollection<MessageItem> messages = new ObservableCollection<MessageItem>();
        public event EventHandler<string> MessageEntered;

        public ChatWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            lbMessages.ItemsSource = messages;
            
            #if (SERVER)
                //Start chat server
                new WpfChatServer(this).Start();
            #endif

            #if (CLIENT)
                //Start chat client
                new WpfChatClient(this).Start();
            #endif
        }

        public void AddMessage(string message)
        {
            Dispatcher.InvokeAsync(() =>
            {
                messages.Add(CreateMessageItem(message));
                scrollViewerMessages.ScrollToBottom();
            });
        }

        private MessageItem CreateMessageItem(string message)
        {
            var item = new MessageItem
            {
                Message = message,
                Time = DateTime.Now.ToString("HH:mm:ss")
            };

            return item;
        }

        private void btnEnterMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            MessageEntered?.Invoke(this, txtMessage.Text);
            txtMessage.Text = string.Empty;
        }

        private void ChatWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
