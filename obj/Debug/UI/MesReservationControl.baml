   M S B A M L   `   `   `  ����B  >WaveWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WaveWpf.UI
WaveWpf.UI  5      &     WaveWpf.UI.MesReservationControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WaveWpf.UI     5      .��5	      � ���	#FF3E4A67$	��420��6"   $	��785��6/   .+�5
   
   �� $��Mes réservations��6   $��Center=�6+   $��58��6O   $��Comic Sans MS)�6[   $��35(�6v   ���	#FFAEC5E4$��10,2,-10,360q�6�   �� 5   
   $%��/logo_wave-removebg-preview.png��6   $��13,2,595,362q�69   �� 5   
   -   5          ��Name$  label_user_email��5      $��Label��6*   $
��Left=�6:   $��43��6U   $��	50,71,0,0q�6a   $	��Top=�6t   $	��601��6�   $��Comic Sans MS)�6�   $��25(�6�   ���	#FFAEC5E46�   �� 5   
   -   5        $  label_user_id��5      $��Label��6'   $
��Left=�67   $��11��6R   $��	50,48,0,0q�6^   $	��Top=�6q   $	��601��6�   $��Comic Sans MS)�6�   $��25(�6�   ���	#FFAEC5E4$y�Hidden=�6�   �� 5   
   -   5        $  label_user_message��5      $0��*Vous n'avez pas encore de réservations ! ��6,   $
��Left=�6`   $��56��6{   $��
50,146,0,0q�6�   $	��Top=�6�   $	��601��6�   $��Comic Sans MS)�6�   $��25(�6�   ���	#FFAEC5E4$y�Hidden=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridMesReservation��5      $
��Left=�63   $	��211��6N   $��
66,161,0,0q�6[   $	��Top=�6o   $	��670��6�      CanUserAddRows .     AutoGenerateColumns .  ��6�   �� *Reservations+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nom du groupe��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 235 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	NomGroupe+6Z     5      $
 Jour��6%   $	 110 6L    63   �� *Jour+6L     5      $ Adresse��6%   $	 250 6R    66   �� *	Adresse+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 
Annulation��6)      CellTemplate 5      �� 5      .R�5      �� -   5        $��Annuler��5   %   ��6`   �� *Id+5      5      5      5      5       