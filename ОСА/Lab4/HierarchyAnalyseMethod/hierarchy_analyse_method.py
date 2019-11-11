import numpy

def nth_degree_root(number, degree):
    """
    Function to get the root of n-th degree from number
    Args:
    - number (float) : radical expression
    - degree (float) : root degree
    Return:
    - N-th degree root from number
    """
    return number ** (1 / degree)

def get_criteria_priorities(comparison_matrix):
    """
    Function to get the priorities on each criteria based on
    comparison matrix (m x m) prepared by experts
    Args:
    - comparison_matrix (numpy.matrix) : criterias comparison matrix
    Return:
    - list of m criteria priorities
    """
    criteria_priorities = []
    matrixSum = comparison_matrix.sum()

    for row in comparison_matrix.tolist():
        criteria_priorities.append(sum(row) / matrixSum)

    return criteria_priorities

def get_alternatives_criterias_values(criteria_characteristics):
    """
    Function to get matrix of respective estimations 
    of all alternatives for one specific criteria represented by vector
    Args:
    - criteria_characteristics (list) : list of characteristics for one criteria
    Return:
    - list of alternative estimation for one characteristic
    """
    N                 = len(criteria_characteristics)
    comparison_matrix = []
    priorities        = []
    
    for i in range(0, N):
        row = []
        for j in range(0, N):
            row.append(criteria_characteristics[i] / criteria_characteristics[j])
        comparison_matrix.append(row)
    
    for i in range(0, N):
        priorities.append(nth_degree_root(numpy.prod(comparison_matrix[i]), N))
    priorities_sum = sum(priorities)
    for i in range(0, N):
        priorities[i] = priorities[i] / priorities_sum

    return priorities

def enter_matrix_from_file(rows, columns, path):
    """
    Function to input matrix from file. Elements of matrix 
    in file should be separated by one space. Use rows/columns
    args to limit dimentions of resulting matrixes.
    Args:
    - rows (int) : number of rows in resulting matrix
    - columns (int) : number of columns in resulting matrix
    Return:
    - rows by columns list of lists representation of matrix
    """
    matrix = []
    file = open(path)
    
    for i in range(0, rows):
        matrix.append(
            list(map(float, file.readline().split()[0:columns]))
        )

    return matrix

def get_alternatives_total_estimation(criterias, alternatives, criterias_priorities_matrix, characteristics_matrix):
    """
    Function to count total estimation value of each alternative
    Args:
    criterias (int) : criterias number
    alternatives (int) : alternatives number
    criterias_priorities_matrix (list) : matrix of criterias priorities
    characteristics_matrix (list) : matrix of characteristics 
    """
    characteristics      = numpy.matrix(characteristics_matrix)
    criterias_priorities = get_criteria_priorities(numpy.matrix(criterias_priorities_matrix))

    alternatives_respective_values = []
    alternatives_total_estimation  = []

    for row in characteristics.tolist():
        alternatives_respective_values.append(get_alternatives_criterias_values(row))

    for i in range(alternatives):
        total = 0
        for j in range(criterias):
            total += alternatives_respective_values[j][i] * criterias_priorities[j]
        alternatives_total_estimation.append(total)

    return alternatives_total_estimation

characteristics_file_path      = "characteristics.txt"
criterias_priorities_file_path = "criterias_priorities.txt"

print("Enter number of criterias:")
criterias_number = int(input())

print("Enter number of alternatives")
alternatives_number = int(input())

characteristics_matrix      = enter_matrix_from_file(criterias_number, alternatives_number, characteristics_file_path)
criterias_comparison_matrix = enter_matrix_from_file(criterias_number, criterias_number, criterias_priorities_file_path)

alternatives_estimation = get_alternatives_total_estimation(criterias_number, alternatives_number, criterias_comparison_matrix, characteristics_matrix)
print (alternatives_estimation)