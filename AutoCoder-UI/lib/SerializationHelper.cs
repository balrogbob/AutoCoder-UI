using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AutoCoder_UI.lib
{
    public static class SerializationHelper
    {
        public static string LoadSingleSettingFromXMLFile(string settingName)
        {
            try
            {
                // Open a new FileStream object for reading from an XML file
                using (FileStream fileStream = new FileStream("formsettings.xml", FileMode.Open))
                {
                    // Create a new instance of the XmlSerializer class with the type of the custom class
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(FormSettings));

                    // Deserialize the XML file to the custom class instance
                    FormSettings loadedSettings = (FormSettings)xmlSerializer.Deserialize(fileStream);

                    if (loadedSettings != null)
                    {
                        // Return the value of the specified setting name
                        switch (settingName)
                        {
                            case "FilesDir":
                                return loadedSettings.FilesDir;
                            case "ProjectName":
                                return loadedSettings.ProjectName;
                            case "Api_Key":
                                return loadedSettings.Api_Key;
                            case "API_Url":
                                return loadedSettings.API_Url;
                            case "StartTag":
                                return loadedSettings.StartTag;
                            case "endTag":
                                return loadedSettings.EndTag;
                            case "SystemTag":
                                return loadedSettings.SystemTag;

                            default:
                                throw new ArgumentException($"The provided setting name '{settingName}' is not valid.");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while trying to load the form settings from an XML file: {ex.Message}");
            }

            // If no valid result was obtained, return null
            return null;
        }
        public static void SaveSingleSettingToXMLFile(string settingName, string value)
        {
            try
            {
                // Open a new FileStream object for writing to an XML file
                using (FileStream fileStream = new FileStream("formsettings.xml", FileMode.Create))
                {
                    // Create a new instance of the XmlSerializer class with the type of the custom class
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(FormSettings));

                    // Load the existing settings from an XML file, if it exists
                    FormSettings loadedSettings = null;

                    if (File.Exists("formsettings.xml"))
                    {
                        using (XmlTextReader reader = new XmlTextReader("formsettings.xml"))
                        {
                            try
                            {
                                xmlSerializer.Deserialize(reader);
                            }
                            catch (InvalidOperationException)
                            {
                                // Ignore any errors that may occur while trying to deserialize the XML file, since it might not exist yet
                            }
                        }
                    }

                    // If no settings were loaded from an XML file, create a new instance of the custom class and populate its properties with default values
                    if (loadedSettings == null)
                    {
                        loadedSettings = new FormSettings();
                    }

                    // Update the value of the specified setting name in the custom class instance
                    switch (settingName)
                    {                        
                        case "FilesDir":
                            loadedSettings.FilesDir = value; 
                            break;
                        case "ProjectName":
                            loadedSettings.ProjectName = value;
                            break;
                        case "Api_Key":
                            loadedSettings.Api_Key = value;
                            break;
                        case "API_Url":
                            loadedSettings.API_Url = value;
                            break;
                    default:
                            throw new ArgumentException($"The provided setting name '{settingName}' is not valid.");
                    }

                    // Serialize the custom class instance to an XML file
                    xmlSerializer.Serialize(fileStream, loadedSettings);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while trying to save the form settings to an XML file: {ex.Message}");
            }
        }
    }
}
