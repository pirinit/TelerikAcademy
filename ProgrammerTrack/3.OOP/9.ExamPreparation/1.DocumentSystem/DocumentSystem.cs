using System;
using System.Collections.Generic;

public class DocumentSystem
{
    static private List<Document> documents = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        TextDocument doc = new TextDocument(null);
        AddDocument(doc, attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        PDFDocument doc = new PDFDocument(null);
        AddDocument(doc, attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        WordDocument doc = new WordDocument(null);
        AddDocument(doc, attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        ExcelDocument doc = new ExcelDocument(null);
        AddDocument(doc, attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AudioDocument doc = new AudioDocument(null);
        AddDocument(doc, attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        VideoDocument doc = new VideoDocument(null);
        AddDocument(doc, attributes);
    }

    private static void ListDocuments()
    {
        bool noDocuments = true;
        foreach (var doc in documents)
        {
            Console.WriteLine(doc);
            noDocuments = false;
        }

        if (noDocuments)
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool isFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                isFound = true;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }

        if (!isFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool isFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                isFound = true;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }

        if (!isFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool isFound = false;
        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                ((IEncryptable)doc).Encrypt();
                isFound = true;
            }
        }

        if (isFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                isFound = true;
                if (doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
        }

        if (!isFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void AddDocument(Document doc, string[] attributes)
    {
        foreach (string attribute in attributes)
        {
            string[] pair = attribute.Split('=');
            doc.LoadProperty(pair[0], pair[1]);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
}