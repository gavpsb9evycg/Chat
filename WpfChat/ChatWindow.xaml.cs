//#define SERVER
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
        public event EventHandler<string> MessageEntered;

        public ChatWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            messagesListBox.ItemsSource = messages;
            
            #if (SERVER)
                // Start chat server.
                new WpfChatServer(this).Start();
            #endif

            #if (CLIENT)
                // Start chat client.
                new WpfChatClient(this).Start();
            #endif
        }

        public void AddMessage(string message)
        {
            Dispatcher.InvokeAsync(() =>
            {
                messages.Add(CreateMessageItem(message));
                messagesScrollViewer.ScrollToBottom();
            });
        }

        private MessageItem CreateMessageItem(string message)
        {
            var messageItem = new MessageItem
            {
                Message = message,
                Time = DateTime.Now.ToString("HH:mm:ss")
            };

            return messageItem;
        }

        private void enterMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageTextBox.Text))
                return;

            MessageEntered?.Invoke(this, messageTextBox.Text);
            messageTextBox.Text = string.Empty;
        }

        private void ChatWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
