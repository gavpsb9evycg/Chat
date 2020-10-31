// #define SERVER
#define CLIENT

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfChat
{
    /// <summary>
    /// Interaction logic.
    /// </summary>
    public partial class ChatWindow : Window
    {
        private readonly ObservableCollection<MessageItem> messages = new ObservableCollection<MessageItem>();

        public ChatWindow()
        {
            this.InitializeComponent();
            this.Start();
        }

        public event EventHandler<string> MessageEntered;

        private void Start()
        {
            this.messagesListBox.ItemsSource = this.messages;

#if SERVER
            // Start chat server.
            new WpfChatServer(this).Start();
#endif

#if CLIENT
            // Start chat client.
            new WpfChatClient(this).Start();
            #endif
        }

        public void AddMessage(string message)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                this.messages.Add(this.CreateMessageItem(message));
                this.messagesScrollViewer.ScrollToBottom();
            });
        }

        private MessageItem CreateMessageItem(string message)
        {
            var messageItem = new MessageItem
            {
                Message = message,
                Time = DateTime.Now.ToString("HH:mm:ss"),
            };

            return messageItem;
        }

        private void EnterMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.messageTextBox.Text))
            {
                return;
            }

            this.MessageEntered?.Invoke(this, this.messageTextBox.Text);
            this.messageTextBox.Text = string.Empty;
        }

        private void ChatWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
