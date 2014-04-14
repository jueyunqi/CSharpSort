using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CSharpSort
{
    class Sort
    {
        public static int[] GetRandomArray(int num) { 
            int[] result=new int[num];
            System.Random r=new System.Random();

            for (int i = 0; i < num; i++) { 
                result[i]=r.Next(0,10);
            }

            return result;
        }

        public static void print(int[] array)
        {
            if (array.Length < 100) {
                string result = "";
                foreach (int x in array)
                {
                    result += (x + " ");
                }

                Console.WriteLine(result);
            }
         }

        /**************************冒泡排序***********************************************/
        public static void bubbleSort(int[] array)
        {
            /*
            for (int i = 0; i < array.Length - 1; i++) {
                for (int j = 0; j < array.Length - 1 - i; j++) {
                    if (array[j + 1] < array[j]) {
                        array[j] = array[j] ^ array[j + 1];
                        array[j+1] = array[j] ^ array[j + 1];
                        array[j] = array[j] ^ array[j + 1];
                    }
                }
            }*/

            /*
            bool flag = true;
            for (int i = 0;flag&&i < array.Length - 1; i++)
            {
                flag = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        flag = true;
                        array[j] = array[j] ^ array[j + 1];
                        array[j + 1] = array[j] ^ array[j + 1];
                        array[j] = array[j] ^ array[j + 1];
                    }
                }
            }*/
            /*
            bool flag = true;
            int k = array.Length;
            while (flag) {
                flag = false;
                for (int j = 0; j < k - 1; j++) {
                    if (array[j + 1] < array[j])
                    {
                        flag = true;
                        array[j] = array[j] ^ array[j + 1];
                        array[j + 1] = array[j] ^ array[j + 1];
                        array[j] = array[j] ^ array[j + 1];
                    }
                }
                --k;
            }*/

            int k = 0;
            int flag = array.Length;
            while (flag > 0) {
                k = flag;
                flag = 0;
                for (int j = 1; j < k; j++) {
                    if (array[j] < array[j - 1]) {
                        array[j - 1] = array[j - 1] ^ array[j];
                        array[j] = array[j - 1] ^ array[j];
                        array[j - 1] = array[j - 1] ^ array[j];

                        flag = j;
                    }
                }
            }


            Console.WriteLine("\nbubbleSort:");
            print(array);
        }

        /************************直接插入排序***************************************************/
        public static void insertSort(int[] array) {
            /*
            int i = 0, j = 0;
            for (i = 1; i < array.Length; i++) {
                for (j = i-1; j >=0; j--) {
                    if (array[j] < array[i]) break;
                }

                if (j != i-1) {
                    int k=0,temp = array[i];
                    for (k = i-1; k >j; k--) {
                        array[k + 1] = array[k];
                    }
                    array[k+1] = temp;
                }
            }*/

            /*
            int i = 0, j = 0;
            for (i = 1; i < array.Length; i++) {
                if (array[i] < array[i - 1]) { 
                    int temp=array[i];
                    for (j = i - 1; j >= 0 && array[j] > temp;j-- )
                    {
                        array[j+1]=array[j];
                    }
                    array[j + 1] = temp;
                }
            }*/

            
            int i = 0, j = 0;
            for (i = 1; i < array.Length; i++) {
                for (j = i - 1; j >= 0 && array[j] > array[j + 1]; j--) {
                    array[j] = array[j] ^ array[j + 1];
                    array[j+1] = array[j] ^ array[j + 1];
                    array[j] = array[j] ^ array[j + 1];                    
                }
            }



                Console.WriteLine("\ninsertSort:");
            print(array);
        }

        /************************希尔排序*******************************************************/
        public static void shellSort(int[] array) {
            /*
            int i = 0, j = 0, gap = 0;

            for (gap = array.Length / 2; gap > 0; gap /= 2) {
                for (i = 0; i < gap; i++) {
                    for (j = i + gap; j < array.Length; j += gap) {
                        if (array[j] < array[j -gap]) {
                            int temp = array[j];
                            int k = j - gap;

                            while (k >= 0 && array[k] > temp) {
                                array[k + gap] = array[k];
                                k -= gap;
                            }

                            array[k + gap] = temp;
                        }
                    }
                }
            }
             */

            /*
            int j = 0, gap = 0;

            for (gap = array.Length/2; gap > 0; gap /= 2) {
                for (j = gap; j < array.Length; j++) {
                    if (array[j] < array[j - gap]) {
                        int temp = array[j];
                        int k = j - gap;

                        while(k>=0&&array[k]>temp){
                            array[k + gap] = array[k];
                            k -= gap;
                        }

                        array[k + gap] = temp;
                    }
                }
            }
            */

            int i = 0, j = 0, gap = 0;

            for (gap = array.Length / 2; gap > 0; gap /= 2) {
                for (i = gap; i < array.Length; i++) {
                    for (j = i - gap; j >= 0 && array[j] > array[j + gap]; j -= gap) { 
                        array[j]=array[j]^array[j+gap];
                        array[j+gap]=array[j]^array[j+gap];
                        array[j] = array[j] ^ array[j + gap];
                    }
                }
            }


                Console.WriteLine("\nshellSort:");
            print(array);
        }
      

        /************************简单选择排序****************************************************/
        public static void selectSort(int[] array) {
            
            int position = 0;
            for (int i = 0; i < array.Length; i++) {
                int j = i + 1;
                position = i;
                int temp = array[i];
                //找出最小值
                for (; j < array.Length; j++) {
                    if (array[j] < temp) {
                        temp = array[j];
                        position = j;
                    }
                }
                
                array[position] = array[i];
                array[i] = temp;
            }


            /*
            int i = 0, j = 0, minIndex = 0;
            for (i = 0; i < array.Length; i++) {
                minIndex = i;
                for (j = i + 1; j < array.Length; j++) {
                    if (array[j] < array[minIndex]) {
                        minIndex = j;
                    }
                }

                if (minIndex != i) {
                    array[i] = array[i] ^ array[minIndex];
                    array[minIndex] = array[i] ^ array[minIndex];
                    array[i] = array[i] ^ array[minIndex];
                }
            }
            */


            Console.WriteLine("\nselectSort:");
            print(array);
        }

        /**************************** 堆排序***********************/

        /*
        //排序，最大值放在末尾，array虽然是最大堆，在排序后就成了递增的
        public static void heapSort(int[] array)
        {
            buildMaxHeapify(array);

            
            //末尾与头交换，交换后调整最大堆
            for (int i = array.Length - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                maxHeapify(array, i, 0);
            }
       
            Console.WriteLine("\nheapSort:");
            print(array);
        }

        private static void buildMaxHeapify(int[] array)
        {
            //没有子节点的才需要创建最大堆，从最后一个的父节点开始
            int startIndex = getParentIndex(array.Length - 1);
            //从尾端开始创建最大堆，每次都是正确的堆
            for (int i = startIndex; i >= 0; i--)
            {
                maxHeapify(array, array.Length, i);
            }
        }

       
        // 创建最大堆
        // heapSize 需要创建最大堆的大小，一般在sort的时候用到，因为最多值放在末尾，末尾就不再归入最大堆了
        // index 当前需要创建最大堆的位置
        
        private static void maxHeapify(int[] array, int heapSize, int index)
        {
            // 当前点与左右子节点比较
            int left = getChildLeftIndex(index);
            int right = getChildRightIndex(index);

            int largest = index;
            if (left < heapSize && array[index] < array[left])
            {
                largest = left;
            }
            if (right < heapSize && array[largest] < array[right])
            {
                largest = right;
            }
            //得到最大值后可能需要交换，如果交换了，其子节点可能就不是最大堆了，需要重新调整
            if (largest != index)
            {
                int temp = array[index];
                array[index] = array[largest];
                array[largest] = temp;
                maxHeapify(array, heapSize, largest);
            }
        }

       

        // 父节点位置
        private static int getParentIndex(int current)
        {
            return (current - 1) >> 1;
        }

        //左子节点position 注意括号，加法优先级更高
        private static int getChildLeftIndex(int current)
        {
            return (current << 1) + 1;
        }

        // 右子节点position
        private static int getChildRightIndex(int current)
        {
            return (current << 1) + 2;
        }


        //以2为底的对数
        private static double getLog(double param)
        {
            return Math.Log(param) / Math.Log(2);
        }
        */


        // 堆排序算法
        public static void heapSort(int[] array)
        {
            int length = array.Length;
            int tmp = 0;

            // 调整序列的前半部分元素，调整完之后第一个元素是序列的最大的元素
            //length/2-1是第一个非叶节点，此处"/"为整除
            for (int i = (int)((length - 1) / 2); i >= 0; --i) HeapAdjust(array, i, length);

            // 从最后一个元素开始对序列进行调整，不断的缩小调整的范围直到第一个元素
            for (int i = length - 1; i > 0; --i)
            {
                // 把第一个元素和当前的最后一个元素交换，
                // 保证当前的最后一个位置的元素都是在现在的这个序列之中最大的
                ///  Swap(&array[0], &array[i]);
                tmp = array[i];
                array[i] = array[0];
                array[0] = tmp;
                // 不断缩小调整heap的范围，每一次调整完毕保证第一个元素是当前序列的最大值
                HeapAdjust(array, 0, i);
            }

            Console.WriteLine("\nheapSort:");
            print(array);
        }

        // array是待调整的堆数组，i是待调整的数组元素的位置，nlength是数组的长度
        //本函数功能是：根据数组array构建大根堆
        private static void HeapAdjust(int[] array, int i, int nLength){
            int nChild;
            int nTemp;
            for (nTemp = array[i]; 2 * i + 1 < nLength; i = nChild)
                {
                    // 子结点的位置=2*（父结点位置）+ 1
                     nChild = 2 * i + 1;
                     // 得到子结点中较大的结点
                    if ( nChild < nLength-1 && array[nChild + 1] > array[nChild])
                    ++nChild;
                    // 如果较大的子结点大于父结点那么把较大的子结点往上移动，替换它的父结点
                    if (nTemp < array[nChild]){
                        array[i] = array[nChild];
                        array[nChild]= nTemp;
                    }
                    else
                    // 否则退出循环
                    break;
            }

        }

        /***********************************快速排序****************************************************/
        //快速排序
        public static void quickSort(int[] array)
        {
           
            if (array.Length > 0)
            {
                quick(array, 0, array.Length - 1);
            }
            
            //quick_sort(array,0,array.Length-1);

            Console.WriteLine("\nquickSort:");
            print(array);
        }

        private static int getMiddle(int[] list,int low,int high) {
            int temp = list[low];
            while (low < high) {
                while (low < high && list[high] >= temp) {
                    high--;
                }

                list[low] = list[high];
                while (low < high && list[low] <= temp) {
                    low++;
                }
                list[high] = list[low];
            }
            list[low] = temp;

            return low;
        }
        private static void quick(int[] list, int low, int high) {
            if (low < high) {
                int middle = getMiddle(list,low,high);

                quick(list,low,middle-1);
                quick(list,middle+1,high);
            }
        }
    
        private static void quick_sort(int[] array, int left, int right) {
            if (left < right) { 
                int i=left,j=right,x=array[left];

                while (i < j) {
                    while (i < j && array[j] >= x) j--;
                    if (i < j) array[i++] = array[j];

                    while (i < j && array[i] < x) i++;
                    if (i < j) array[j--] = array[i];
                }

                array[i] = x;

                quick_sort(array,left,i-1);
                quick_sort(array,i+1,right);
            }
        } 
        

       

        /**********************归并排序*************************************************************/
        public static void mergeSort(int[] array) {
            //提前开辟全部空间，防止多次开辟空间的时间消耗
            int[] temp=new int[array.Length];
            merge(array,0,array.Length-1,temp);

            Console.WriteLine("\nmergeSort:");
            print(array);
        }
        private static void merge(int[] array, int first, int last, int[] temp) {
            if (first < last) {
                int middle = (first + last) / 2;

                merge(array, first, middle, temp);
                merge(array,middle+1,last,temp);

                mergeArray(array,first,middle,last,temp);
            }
        }
        private static void mergeArray(int[] array,int first,int mid ,int last,int[] temp ) {
            int i = first, j = mid + 1;
            int m = mid, n = last;
            int k = 0;

            while (i <= m && j <= n) {
                if (array[i] < array[j])
                {
                    temp[k++] = array[i++];
                }
                else {
                    temp[k++] = array[j++];
                }
            }

            while (i <= m) {
                temp[k++] = array[i++];
            }
            while (j <= n) {
                temp[k++] = array[j++];
            }


            for (i = 0; i < k; i++) {
                array[i+first] = temp[i];
            }
        }


        /************************************性能测试**************************************************************/
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++) {
                int[] testArray = { 4, 1, 9, 5, 0, 6, 7, 2, 8, 3 };
                //int[] testArray = GetRandomArray(999999);

                Stopwatch watch = new Stopwatch();
                watch.Start();

                //bubbleSort(testArray);

                //insertSort(testArray);

                //shellSort(testArray);

                //selectSort(testArray);

                //heapSort(testArray);

                quickSort(testArray);

                //mergeSort(testArray);


                watch.Stop();
                Console.WriteLine("耗时:" + watch.ElapsedMilliseconds + "ms");
            }

            Console.ReadLine();
        }
    }
}
