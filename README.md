For Developers
============

You can also see [Java](https://github.com/starlangsoftware/Classification), [Python](https://github.com/starlangsoftware/Classification-Py), [Cython](https://github.com/starlangsoftware/Classification-Cy), or [C++](https://github.com/starlangsoftware/Classification-CPP) repository.

## Requirements

* C# Editor
* [Git](#git)

### Git

Install the [latest version of Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git).

## Download Code

In order to work on code, create a fork from GitHub page. 
Use Git for cloning the code to your local or below line for Ubuntu:

	git clone <your-fork-git-link>

A directory called Classification-CS will be created. Or you can use below link for exploring the code:

	git clone https://github.com/starlangsoftware/Classification-CS.git

## Open project with Rider IDE

To import projects from Git with version control:

* Open Rider IDE, select Get From Version Control.

* In the Import window, click URL tab and paste github URL.

* Click open as Project.

Result: The imported project is listed in the Project Explorer view and files are loaded.


## Compile

**From IDE**

After being done with the downloading and opening project, select **Build Solution** option from **Build** menu. After compilation process, user can run Classification-CS.

Detailed Description
============

+ [Classification Algorithms](#classification-algorithms)
+ [Sampling Strategies](#sampling-strategies)
+ [Feature Selection](#feature-selection)
+ [Statistical Tests](#statistical-tests)

## Classification Algorithms

Algoritmaları eğitmek için

	void Train(InstanceList trainSet, Parameter parameters)

Eğitilen modeli bir veri örneği üstünde sınamak için

	string Predict(Instance instance)

Karar ağacı algoritması C45 sınıfında

Bagging algoritması Bagging sınıfında

Derin öğrenme algoritması DeepNetwork sınıfında

KMeans algoritması KMeans sınıfında

Doğrusal ve doğrusal olmayan çok katmanlı perceptron LinearPerceptron ve 
MultiLayerPerceptron sınıflarında

Naive Bayes algoritması NaiveBayes sınıfında

K en yakın komşu algoritması Knn sınıfında

Doğrusal kesme analizi algoritması Lda sınıfında

İkinci derece kesme analizi algoritması Qda sınıfında

Destek vektör makineleri algoritması Svm sınıfında

RandomForest ağaç tabanlı ensemble algoritması RandomForest sınıfında

Basit dummy ve rasgele sınıflandırıcı gibi temel iki sınıflandırıcı Dummy ve 
RandomClassifier sınıflarında

## Sampling Strategies

K katlı çapraz geçerleme deneyi yapmak için KFoldRun, KFoldRunSeparateTest, 
StratifiedKFoldRun, StratifiedKFoldRunSeparateTest

M tane K katlı çapraz geçerleme deneyi yapmak için MxKFoldRun, MxKFoldRunSeparateTest,
StratifiedMxKFoldRun, StratifiedMxKFoldRunSeparateTest

Bootstrap tipi deney yapmak için BootstrapRun

## Feature Selection

Pca tabanlı boyut azaltma için Pca sınıfı

Discrete değişkenleri Continuous değişkenlere çevirmek için DiscreteToContinuous sınıfı

Discrete değişkenleri binary değişkenlere değiştirmek için LaryToBinary sınıfı

## Statistical Tests

İstatistiksel testler için Combined5x2F, Combined5x2t, Paired5x2t, Pairedt, Sign sınıfları
