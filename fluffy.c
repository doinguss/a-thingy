#include <gtk/gtk.h>

//gcc fluffy.c -o fluffy 'pkg-config --cflags gtk+-3.0' 'pkg-config --libs gtk+-3.0'
int main(int argc, char **argv)
    GtkWidget *window;
    gtk_init(&argc,&argv);

    window=gtk_window_new(GTK_WINDOW_TOPLEVEL);
    g_signal_connect(window,"destroy",G_CALLBACK(gtk_main_quit),NULL);
    gtk_window_set_decorated():

    gtk_widget_show_all(window);
    gtk_main();
    return 0;
}
//refrences
//https://www.youtube.com/watch?v=ajNvsv1ka4I
//https://docs.gtk.org/gtk3/
