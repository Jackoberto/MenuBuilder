# MenuBuilder
School Project At Forsbergs Skola

Unity Plugin MenuBuilder By:

Jack Karlsson, Fredrik Wallander, Simon Magnusson, Eric Sjöberg, Frida Curman, Kalle Jenefors, Sophie Ahlberg

## Installaion + Usage Guide
For Extended [Installation Guide And Usage](https://docs.google.com/document/d/1hvqBy5Zh6iBI-GP4659pduJMZ2MF5kVik2VWZRg_E8o/edit?usp=sharing)

### Menu Builder Usage
Use the Hierarchy context menu or GameObject menu to choose a template or empty menu

Highlight the MenuBuilder that is set as a child object in the canvas to see the MenuBuilder in the inspector.

Choose what you want to add to your menu by dragging the element slider and pressing the add button.

You can name the object that you want to add or it will be set to a default name. 

The “Default” drop down menu offers different options for every component.

## Extension Guide
### Simple: 

You can create your own Scriptable Objects and connect your own prefabs, then add them to the Menu script inside the Menu Element Configs array.

### Advanced: 

If you want to add more UI elements, you can Inherit from MenuBuilder.Configs.Element, Extra Options can be added by declaring parmaterless methods with the Attribute ExtraOption. For Instantion of prefabs use the prefabInstantiator and for setting persistent events use the eventTools parameters within the Create method
