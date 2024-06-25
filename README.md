# AWS IAM Identity Center Management Script

This repository contains a Bash script to manage AWS IAM Identity Center (formerly AWS Single Sign-On) users, groups, accounts, and permissions. The script allows you to list users, groups, accounts, and permission sets, and to add or remove user roles and policies to/from accounts.

## Prerequisites

Before using the script, ensure you have the following:
1. AWS CLI installed and configured with appropriate permissions.
2. Access to an AWS IAM Identity Center instance and its identity store ID.
3. Sufficient permissions to manage users, groups, accounts, and permission sets in AWS.

## Usage

1. **Clone the Repository**

    ```sh
    git clone https://github.com/yourusername/aws-iam-identity-center-management.git
    cd aws-iam-identity-center-management
    ```

2. **Set Instance Details**

    Open the script and set the `INSTANCE_ARN` and `IDENTITY_STORE_ID` variables with your AWS IAM Identity Center instance details:

    ```sh
    INSTANCE_ARN="arn:aws:sso:::instance/ssoins-72235eb9bafe67a6"
    IDENTITY_STORE_ID="d-9067e774ed"
    ```

3. **Run the Script**

    Make the script executable and run it:

    ```sh
    chmod +x manage_identity_center.sh
    ./manage_identity_center.sh
    ```

4. **Main Menu Options**

    The script provides the following options:
    
    1. **List Users**: Lists all users in the identity store.
    2. **List Groups**: Lists all groups.
    3. **List AWS Organization Accounts**: Lists all AWS organization accounts.
    4. **List Permission Sets**: Lists all permission sets in the instance.
    5. **Add User Roles and Policies to an Account**: Adds roles and policies to a specified user for a specified account.
    6. **Add Multiple Users with Multiple Policies to Multiple Accounts**: Adds multiple users with multiple policies to multiple accounts.
    7. **Remove User Roles and Policies from an Account**: Removes roles and policies from a specified user for a specified account.
    8. **Remove Multiple Users' Roles and Policies from Multiple Accounts**: Removes multiple users' roles and policies from multiple accounts.
    9. **Exit**: Exits the script.

## Example Usage

### Adding a User Role and Policy to an Account

1. Select option `5` from the main menu.
2. Enter the display name of the user.
3. Enter the permission set ARN.
4. Enter the account ID.

### Removing Multiple Users' Roles and Policies from Multiple Accounts

1. Select option `8` from the main menu.
2. Enter the display names of the users, comma-separated (e.g., `user1,user2`).
3. Enter the permission set ARNs, comma-separated (e.g., `arn:aws:sso:::permissionSet/ssoins-72235eb9bafe67a6/ps-12345678,arn:aws:sso:::permissionSet/ssoins-72235eb9bafe67a6/ps-87654321`).
4. Enter the account IDs, comma-separated (e.g., `123456789012,210987654321`).

The script will iterate through each user, account, and permission set to remove the roles and policies accordingly.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
