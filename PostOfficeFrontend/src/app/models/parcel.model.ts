export interface ParcelModel {
    id: number,
    recipient: string,
    weight: number,
    phone: string,
    info: string,
    postId: string,
    post: Post
};

export interface Post {
    id: number,
    name: string
};