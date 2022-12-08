using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Dag07 : Dag
    {
        public Dag07(string s) : base(s)
        {
            
        }
        folder root;
        folder currentDir;
        int index;
        public override void Puzzel1()
        {
            index = 0;
            root = new folder("root", null);
            currentDir = root;
            for (; index < lines.Length;)
                parseInstruction(lines[index]);
            List<int> selectedFolders = new List<int>();
            getAllSizes(root, selectedFolders);
            this.result1 = selectedFolders.Sum().ToString();

        }

        public void getAllSizes(folder startfolder, List<int> resultList)
        {
            int currentSize = startfolder.getSize();
            if (currentSize < 100000)
                resultList.Add(currentSize);
            foreach(KeyValuePair<string,dirObject> child in startfolder.getChildren())
                if (child.Value is folder)
                    getAllSizes((folder)child.Value, resultList);
        }
        
        public override void Puzzel2()
        {
            int remaining = 70000000 - root.getSize();
            int required = 30000000 - remaining;
            List<int> candidates = new List<int>();
            findCandidates(root, candidates, required);
            candidates.Sort();
            this.result2 = candidates[0].ToString();

        }

        public void findCandidates(folder folder, List<int> resultlist, int target)
        {
            int currentSize = folder.getSize();
            if (currentSize > target)
                resultlist.Add(currentSize);
            foreach (KeyValuePair<string, dirObject> child in folder.getChildren())
                if (child.Value is folder)
                    findCandidates((folder)child.Value, resultlist, target);
        }


        public void parseInstruction(string instruction)
        {
            string debug = instruction[2..4];
            if (instruction[0] == '$')
                switch(instruction[2..4])
                {
                    case "cd":
                        changeDir(instruction[5..^0]);
                        break;
                    case "ls":
                        list();
                        break;
                }
        }

        public void changeDir(string newDir)
        {
            if (newDir == "/")
                currentDir = root;
            else if (newDir == "..")
            {
                if (currentDir.parent != null)
                    currentDir = currentDir.parent;
            }
            else
                currentDir = (folder)currentDir.getChildren()[newDir];
            index++;
        }

        public void list()
        {
            index++;
            while (index < lines.Length && lines[index][0] != '$')
            {
                string[] addObj = lines[index].Split(' ');
                int size = 0;
                if (int.TryParse(addObj[0], out size))
                    currentDir.giveChild(new file(addObj[0], addObj[1], currentDir));
                else
                    currentDir.giveChild(new folder(addObj[1], currentDir));
                index++;
            }
        }

    }

    public class dirObject
    {
        public dirObject(string name, folder p)
        {
            this.name = name;
            parent = p;
        }

        public dirObject(string name)
        {
            this.name = name;
        }

        public string name;
        public folder? parent;

        public int getSize()
        {
            return size;
        }

        public virtual void setSize(int s)
        {
            size = s;
            if (parent != null)
                parent.setSize();
        }

        public virtual void setSize()
        {

        }
        private int size;
    }

    public class file : dirObject
    {
        public file(string s, string n, folder p) : base(n,p)
        {
            setSize(int.Parse(s));
        }
    }

    public class folder : dirObject
    {
        public folder(string n, folder p) : base(n,p)
        {
            children = new Dictionary<string, dirObject>();
            setSize(0);
        }
        private Dictionary<string, dirObject> children;

        public void giveChild(dirObject child)
        {
            children.Add(child.name,child);
            setSize();
            if(parent!= null)
                parent.setSize();
        }

        public Dictionary<string,dirObject> getChildren()
        {
            return children;
        }
         public override void setSize()
        {
            int s = 0;
            foreach(dirObject x in children.Values)
                s += x.getSize();
            setSize(s);
        }
    }
}
