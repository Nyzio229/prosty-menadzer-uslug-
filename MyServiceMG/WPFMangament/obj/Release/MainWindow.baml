   M S B A M L   `   `   `  ���� G  CWPFMangament, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPFMangamentWPFMangament      WPFMangament.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:WPFMangament       � Title$  My Service Manager��$	��450��$	��800��.���  � ColumnDefinitions �� $
��199* ��� $
��201* � � RowDefinitions �� $	��65* ��� $	��65* ��� $	��94* ��� $	��56* ��� $
��154* �.+��� -    ��Name$ bStart��$��Start�� J� RenderTransformOrigin$ 0.544,-0.123&�$��2��$��
10,10,10,9q��� -   $ bStop��$
��Stop��$��1��$��2��$��10,10,10,10q��� -    ��Name$ statusLabel��$��Aktywuj��$��2��$��Arial Black)�$��Center=�$��Center=�$��22(�$��2��$��20,10,20,10q��� -   $ refreshButton��$��Refresh Logs��$��3��$��	10,5,10,4q��� -   $ clearButton��$��
Clear Logs��$��3��$��1��$��	10,5,10,4q��� $
��Auto=�$��2��$��
10,5,20,10q�$��4��.���� -    ��Name$ eventLogTextBox��$��	20,9,20,9q�$��4�� �� TextWrapping$
 Wrap=�$��2��{�.  