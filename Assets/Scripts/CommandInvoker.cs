using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static List<ICommand> commandHist;
    static int counter; 
    static Queue<ICommand> commandBuffer;
    private void Awake()
    {
        commandBuffer = new Queue<ICommand>();
    }

    public static void AddCommand(ICommand command)
    {
        commandBuffer.Enqueue(command);
        if (counter < commandHist.Count)
        {
            while (commandHist.Count > counter)
            {
                commandHist.RemoveAt(counter);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            commandHist.Add(c);
            counter++;
        }
        else
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                if (counter > 0)
                {
                    counter--;
                    commandHist[counter].Undo();
                }
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                try
                {
                    if (counter < commandHist.Count)
                    {
                        commandHist[counter].Execute();
                        counter++;
                    }
                }
                catch(Exception e) {
                    print(e);
                }
            }
        }
    }
}
