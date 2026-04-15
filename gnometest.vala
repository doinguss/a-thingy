using Gtk;

//valac --pkg gtk+-3.0 gnometest.vala && ./gnometest
Window window;
static int main(string[] args){
    init(ref args);
    //var header=new HeaderBar();
    //header.set_show_close_button(true);
    
    window = new Window();
    window.destroy.connect(main_quit);
    window.set_default_size(500,500);
    //window.set_titlebar(header);
    
    window.show_all();
    Gtk.main();
    return 0;
    }
    
    //https://www.youtube.com/watch?v=4aKr8_QTOSI
